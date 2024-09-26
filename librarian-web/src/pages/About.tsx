import React from 'react';
import { useSelector } from 'react-redux';
import { RootState } from '@state/appStore';
import { useResolvedPath } from 'react-router-dom';
import { useForm } from 'react-hook-form';

interface FormData {
  name: string;
  email: string;
}

const About: React.FC = () => {
  const { register, handleSubmit, formState: { errors } } = useForm<FormData>();

  const onSubmit = (data: FormData) => {
    console.log(data);
  };

  return (
    <div className="max-w-md mx-auto mt-10 p-6 bg-white shadow-md rounded-lg">
      <h2 className="text-2xl font-bold text-center mb-6">My Form</h2>
      <form onSubmit={handleSubmit(onSubmit)}>
        <div className="mb-4">
          <label className="block text-sm font-medium text-gray-700">Name</label>
          <input
            {...register('name', { required: true })}
            className={`mt-1 block w-full border rounded-md p-2 ${
              errors.name ? 'border-red-500' : 'border-gray-300'
            }`}
            placeholder="Enter your name"
          />
          {errors.name && <span className="text-red-500 text-sm">This field is required</span>}
        </div>
        <div className="mb-4">
          <label className="block text-sm font-medium text-gray-700">Email</label>
          <input
            {...register('email', { required: true })}
            className={`mt-1 block w-full border rounded-md p-2 ${
              errors.email ? 'border-red-500' : 'border-gray-300'
            }`}
            placeholder="Enter your email"
          />
          {errors.email && <span className="text-red-500 text-sm">This field is required</span>}
        </div>
        <button
          type="submit"
          className="w-full bg-blue-500 text-white py-2 rounded-md hover:bg-blue-600"
        >
          Submit
        </button>
      </form>
    </div>
  );
};

export default About;